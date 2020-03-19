# Locator
MVC Razor Page ATM Locator

## Views - Locations - Index
This is the index page that renders as Home and contains the  map, the card sidebar and the filter search options. It uses a 3 column layout.
1. div#filter-wrapper
- This column contains the filter/search fields
2. div#center-index
- This column contains the Google Map block
3. div#sidebar
- This column contains the list of ATM object cards

## LocationsController
Two Primary Methods
1. Index()
- Returns the results from the CleanLocationViewModel to div#sidebar in the Index View.
- The ATM Object Cards that render in the right column are derived from this method.
2. CardJson()
- Returns the results from the CleanLocationViewModel to the Ajax call in mapMethods.js at GetJsonData().
- The ATM Object Map Markers that render on the Google Map are derived from this method. 

## CleanLocationViewModel
This ViewModel generates the list of ATM object cards which are rendered to the razor page model. The list is generated from the CleanLocationModel.

## CleanLocationModel
This model has 3 partial classes
1. CleanLocationModel_properties
- This partial class is a declaration of all attributes in the Database Library Locations Model which will be used to create ATM objects for both cards and map marker pins.
2. CleanLocationModel_methods
- This partial class is the implementation of the parsing logic which scrubbs null and undefined values before being passed on to the CleanLocationViewModel.
3. CleanLocationModel_builder
- This partial class generates the raw html tags that will populate the Razor page
-   

