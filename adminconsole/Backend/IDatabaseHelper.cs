using adminconsole.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseLibrary.Models;


namespace adminconsole.Backend
{
    public interface IDatabaseHelper
    {

        public Task<Locations> ReadOneRecordAsync(string referenceId);






        /// <summary>
        /// Reads all records from database. 
        /// </summary>
        /// 
        /// 
        /// <param name="isDeleted"> If true, return soft deleted records, otherwise return existing records </param>
        /// 
        /// 
        /// <returns> List<Locations> object if any records in databse, otherwise returns null </returns>
        public Task<List<Locations>> ReadMultipleRecordsAsync(bool isDeleted = false);







        /// <summary>
        /// Alters location record information, whether it be through: 
        ///     CREATING a new record,
        ///     UPDATING a prexisting record,
        ///     DELETING a preexisting record, or
        ///     RECOVERING a delete Locations record
        /// </summary>
        /// 
        /// 
        /// <param name="context"> MaphawksContext class object </param>
        /// <param name="action"> AlterRecordInfoEnum type. Create, Update, Delete or Recover</param>
        /// <param name="table"> Maphawks Database table (model class) </param>
        /// 
        /// <returns> Returns true on success, otherwise returns false </returns>
        public bool AlterRecordInfo(AlterRecordInfoEnum action, IMaphawksDatabaseTable table);





        /// <summary>
        /// Adds a row in Contacts, SpecialQualities, or DailyHours table if one didn't exist before an edit.
        /// 
        /// Deletes a row in Contacts, SpecialQualities, or DailyHours table if after an edit an entire row's fields are null.
        /// </summary>
        /// 
        /// 
        /// <param name="referenceRow"> The row before the edit </param>
        /// <param name="editedRow"> The row after the edit </param>
        public void _AddDeleteRow(IMaphawksDatabaseTable referenceRow, IMaphawksDatabaseTable editedRow);







        /// <summary>
        /// Determines if a GUID is already associated with a Location record. 
        /// </summary>
        /// 
        /// 
        /// <param name="id"> Database field LocationId </param>
        /// 
        /// 
        /// <returns> Returns true if the LocationId is already associated with a Location record, false otherwise </returns>
        public bool LocationIdNotUnique(string id);







        public bool SaveChanges();
    }
}