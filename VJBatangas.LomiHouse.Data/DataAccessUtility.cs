using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using VJBatangas.LomiHouse.Common;

namespace VJBatangas.LomiHouse.Data
{
    public static class DataAccessUtility
    {

        public static void ExecuteSingleQuery<TTargetType>(this Database db,
                                                           DbCommand command,
                                                           Func<IDataReader, TTargetType> dataReaderConverter,
                                                           ICollection<TTargetType> resultList)
        {
            ExecuteSingleQuery<TTargetType, Func<IDataReader, TTargetType>>(
                db,
                dataReaderConverter,
                command,
                (state, datareader) =>
                {
                    Func<IDataReader, TTargetType> actualConverter = (Func<IDataReader, TTargetType>)state;
                    return actualConverter(datareader);
                },
                resultList);
        }

        public static void ExecuteSingleQuery<TTargetType, TThisCallState>(this Database db,
                                                                           TThisCallState callState,
                                                                           DbCommand command,
                                                                           Func<TThisCallState, IDataReader, TTargetType> dataReaderConverter,
                                                                           ICollection<TTargetType> resultList)
        {

            Func<
                 Tuple<TThisCallState, Func<TThisCallState, IDataReader, TTargetType>, ICollection<TTargetType>>,
                 IDataReader,
                 TTargetType> wrappedDataReaderConverter = (tuple, datareader) =>
                 {
                     TThisCallState actualState = tuple.Item1;
                     Func<TThisCallState, IDataReader, TTargetType> actualConverter = tuple.Item2;
                     return actualConverter(actualState, datareader);
                 };

            Action<Tuple<TThisCallState, Func<TThisCallState, IDataReader, TTargetType>, ICollection<TTargetType>>,
                TTargetType> onEachRowAction = (tuple, row) => 
                {
                    ICollection<TTargetType> targetCollection = tuple.Item3;
                    targetCollection.Add(row);
                };

            Tuple<TThisCallState, Func<TThisCallState, IDataReader, TTargetType>, ICollection<TTargetType>> 
                wrappedState = new Tuple<TThisCallState, Func<TThisCallState, IDataReader, TTargetType>, ICollection<TTargetType>>(callState, dataReaderConverter, resultList);

            ExecuteSingleQuery(db, wrappedState, command, wrappedDataReaderConverter, onEachRowAction);

        }

        public static void ExecuteSingleQuery<TTargetType, TThisCallState>(
            this Database db,
            TThisCallState callState,
            DbCommand command,
            Func<TThisCallState, IDataReader, TTargetType> dataReaderConverter,
            Action<TThisCallState, TTargetType> onEachRow)
        {
            ValidationHelper.ValidateNonNullArgument(command, "command");
            ValidationHelper.ValidateNonNullArgument(dataReaderConverter, "dataReaderConverter");
            ValidationHelper.ValidateNonNullArgument(onEachRow, "onEachRow");
            using (IDataReader reader = db.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    TTargetType row = dataReaderConverter(callState, reader);
                    onEachRow(callState, row);
                }
            }
        }

        public static T Retrieve<T>(IDataReader reader, String fieldName)
        {
            object fieldValue = reader[fieldName];
            T convertedValue = GenericTypeConverter.ConvertValue<T>(fieldValue);
            if (convertedValue != null && convertedValue is DateTime)
            {
                object o1 = convertedValue;
                object o2 = GenericTypeConverter.ToUtc((DateTime)o1);
                return (T)o2;
            }
            else
            {
                return convertedValue;
            }
        }

        public static void AddParameterName(this IDbCommand dbCmd, String name)
        {
            IDbDataParameter parameter = dbCmd.CreateParameter();
            parameter.ParameterName = name;
            dbCmd.Parameters.Add(parameter);
        }

    }
}
