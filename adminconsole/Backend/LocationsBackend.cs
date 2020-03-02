using adminconsole.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DatabaseLibrary.Models;


namespace adminconsole.Backend
{
    public class LocationsBackend
    {
        private DatabaseHelper db;

        public Exception errorMessage = null;



        public LocationsBackend(IDatabaseHelper mockDb)
        {
            db = (DatabaseHelper)mockDb;
        }



        /// <summary>
        /// 
        /// Constructor with DB Context for Live Dependency Injection
        /// 
        /// </summary>
        /// 
        /// 
        /// <param name="context"> DB Context Object </param>
        public LocationsBackend(MaphawksContext context)
        {
            db = new DatabaseHelper(context);
        }






        /// <summary>
        /// 
        /// Gets all Locations Objects with a join on all tables on LocationId. 
        /// If deleted == false: fetches live records (SoftDelete != true)
        /// If deleted == true: fetched deleted records (SoftDelete == true)
        /// 
        /// </summary>
        /// 
        /// 
        /// <param name="deleted"> Lets you choose between deleted or live Locations records </param>
        /// 
        /// 
        /// <returns> Returns List of Locations Objects </returns>
        public virtual async Task<List<Locations>> IndexAsync(bool deleted = false)
        {
            var locations_list = new List<Locations>();

            locations_list = await db.ReadMultipleRecordsAsync(deleted).ConfigureAwait(false); // Select * join all tables


            foreach (var location in locations_list)
            {
                ConvertDbStringsToEnums(location);
            }
            return locations_list;
        }






        /// <summary>
        /// 
        /// Gets a single Locations record with a join on all tables on LocationId
        /// 
        /// </summary>
        /// 
        /// 
        /// <param name="id">  The string ID of the Location record requested by the user </param>
        /// 
        /// 
        /// <returns> Returns a single Locations Object </returns>
        public virtual async Task<Locations> DetailsAsync(string id)
        {

            var resultLocation = await db.ReadOneRecordAsync(id).ConfigureAwait(false);
            if (resultLocation == null)
            {
                return null;
            }

            ConvertDbStringsToEnums(resultLocation);
            return resultLocation;

        }







        /// <summary>
        /// 
        /// Creates new Locations, Contacts, SpecialQualities, DailyHours.
        /// 
        /// </summary>
        /// 
        /// 
        /// <param name="newLocation"> ViewModel with properties corresponding to the fields for each table </param>
        /// 
        /// 
        /// <returns> 
        /// 
        /// False: If newLocation is null or there was an error when attempting to insert
        /// True: It newLocation is successfully inserted into the Database
        /// 
        /// </returns>
        public virtual bool Create(AllTablesViewModel newLocation)
        {
            if (newLocation == null) // Non-valid ViewModel Object
            {
                return false;
            }

             // Ensures we don't end up with any duplicate LocationIds
            while (db.LocationIdNotUnique(newLocation.LocationId))
            {
                newLocation.LocationId = Guid.NewGuid().ToString();
            }



            Locations location = AllTablesViewModel.GetNewLocation(newLocation);
            Contacts contact = AllTablesViewModel.GetNewContact(newLocation);
            SpecialQualities specialQuality = AllTablesViewModel.GetNewSpecialQualities(newLocation);
            DailyHours dailyHours = AllTablesViewModel.GetNewDailyHours(newLocation);



            try
            {
                db.AlterRecordInfo(AlterRecordInfoEnum.Create, location);

                if (contact != null)
                {
                    db.AlterRecordInfo(AlterRecordInfoEnum.Create, contact);
                }


                if (specialQuality != null)
                {
                    db.AlterRecordInfo(AlterRecordInfoEnum.Create, specialQuality);
                }



                if (dailyHours != null)
                {
                    db.AlterRecordInfo(AlterRecordInfoEnum.Create, dailyHours);
                }


                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;


        }





        /// <summary>
        /// 
        /// Gets a single Locations Object from the Database given an LocationId.
        /// Used by LocationsController: Edit (Post), Delete (Get)
        /// 
        /// </summary>
        /// 
        /// 
        /// <param name="id"> The string ID of a Locations Object </param>
        /// 
        /// 
        /// <returns> If the record doesn't exist returns NULL, otherwise returns the Locations Object </returns>
        public virtual async Task<Locations> GetLocationAsync(string id)
        {
            if (id == null)
            {
                return null;
            }

            Locations location;

            
            location = await db.ReadOneRecordAsync(id).ConfigureAwait(false);

            if (location != null)
            {
                ConvertDbStringsToEnums(location);
            }

            return location;
        }







        /// <summary>
        /// 
        /// Gets the Location Object given a LocationId for the User to Edit upon
        /// 
        /// </summary>
        /// 
        /// <param name="id"> The string ID of the Locations Object the user wants to Edit </param>
        /// 
        /// <returns> 
        /// 
        /// NULL: If Location record does not exist with the given ID
        /// Locations Object: If the record was found in the Database
        /// 
        /// </returns>
        public virtual async Task<AllTablesViewModel> EditAsync(string id)
        {
            if (id == null)
            {
                return null;
            }


            AllTablesViewModel locationViewModel = null;

            var location = await db.ReadOneRecordAsync(id).ConfigureAwait(false); // Get Location from Database

            if (location != null)
            {
                locationViewModel = new AllTablesViewModel(location);
            }


            return locationViewModel;
        }







        /// <summary>
        /// 
        /// Updates the Location Record in the Database
        /// 
        /// </summary>
        /// 
        /// 
        /// <param name="newLocation"> ViewModel Object containing the data for the fields of all the tables provided by the user </param>
        /// 
        /// 
        /// <returns>
        /// 
        /// True: If successfully updates Location record in DB
        /// False: If newLocation is null, of if there was a Database Update error
        /// 
        /// </returns>
        public virtual async Task<bool> EditPostAsync(AllTablesViewModel newLocation)
        {
            if (newLocation == null)
            {
                return false;
            }



            // Get each table's Object
            Locations location = AllTablesViewModel.GetNewLocation(newLocation);
            location.Contact = AllTablesViewModel.GetNewContact(newLocation);
            location.SpecialQualities = AllTablesViewModel.GetNewSpecialQualities(newLocation);
            location.DailyHours = AllTablesViewModel.GetNewDailyHours(newLocation);


            bool result = false; // Value to be returned

            try
            {
                Locations response = await db.ReadOneRecordAsync(newLocation.LocationId).ConfigureAwait(true);

                if (response is null)  // Location does not exist
                {
                    return false;
                }

                db._AddDeleteRow(response.Contact, location.Contact);
                db._AddDeleteRow(response.SpecialQualities, location.SpecialQualities);
                db._AddDeleteRow(response.DailyHours, location.DailyHours);


                response = location;

                result = db.AlterRecordInfo(AlterRecordInfoEnum.Update, response);

                return result;
            }
            catch (Exception e)
            {
                errorMessage = e;
                return false;
            }
        }








        /// <summary>
        /// 
        /// Soft Deletes a Locations Object.
        /// 
        /// </summary>
        /// 
        /// <param name="id"> The string ID of the Locations Object the user wants to Delete </param>
        /// 
        /// <returns>
        /// 
        /// True: If successfully updates SoftDelete field to True
        /// False: If Database error or if the LocationId does not exist in Database
        /// 
        /// </returns>
        public virtual async Task<bool> DeleteConfirmedAsync(string id)
        {

            if (id == null)
            {
                return false;
            }

            Locations locations;

            locations = await db.ReadOneRecordAsync(id).ConfigureAwait(false);
           

            if (locations == null) // Record not found
            {
                return false;
            }

            locations.SoftDelete = true;

            try
                {
                    db.AlterRecordInfo(AlterRecordInfoEnum.Update, locations);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            

        }







        /// <summary>
        /// 
        /// Recovers a deleted Locations record
        /// 
        /// </summary>
        /// 
        /// 
        /// <param name="id"> The string ID for the Locations Object the user wants to recover </param>
        /// 
        /// 
        /// <returns>
        /// 
        /// True: If the Locations record's SoftDelete field was successfully changed to False
        /// False: If there was a Database error when trying to Update the Locations record
        /// 
        /// </returns>
        public virtual async Task<bool> RecoverAsync(string id)
        {
            if (id == null)
            {
                return false;
            }

            Locations location = new Locations();

            // Get the record
            location = await db.ReadOneRecordAsync(id).ConfigureAwait(false);


            



            if (location is null)  // Location doesn't exist
            {
                return false;
            }


            // Change SoftDelete value to False
            location.SoftDelete = false;


            try
                {
                    db.AlterRecordInfo(AlterRecordInfoEnum.Update, location);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

        }




        /// <summary>
        /// 
        /// Converts Database State and LocationType strings to their corresponding Enum values so that we can use these values in the ViewModel.
        /// 
        /// </summary>
        /// 
        /// 
        /// <param name="location"> A Locations Object </param>
        /// 
        /// <returns> The Updated Location. </returns>
        private static Locations ConvertDbStringsToEnums(Locations location)
        {
            var state = AllTablesViewModel.ConvertStringToStateEnum(location.State);
            var locationType = AllTablesViewModel.ConvertStringToLocationTypeEnum(location.LocationType);



            location.State = state.GetType().GetMember(state.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name;


            location.LocationType = locationType.GetType().GetMember(locationType.ToString()).First().GetCustomAttribute<DisplayAttribute>().Name;

            return location;
        }
    }
       
}
