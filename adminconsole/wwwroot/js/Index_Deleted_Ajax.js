// Ajax call to get more records from a database

var rowCount = $('tr').length - 1;

$(document).ready(function () {

    $.post("../locations/getrangeofrecords",
        {
            start_index: rowCount,
            num_records: 10
        },
        function (data, status) {
            var dataAsHtml = $.parseHTML(data);
            $("tbody").append(dataAsHtml);
        });
});