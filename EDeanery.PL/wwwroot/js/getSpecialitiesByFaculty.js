function getSpecialtiesByFacultyId(facultyId) {
    $.ajax({
        url: "/Students/GetSpecialitiesByFacultyId/" + facultyId,
        cache: false,
        type: "GET",
        success: function (data) {
            var markup = "<option value='0'>Select City</option>";
            
            for (var x = 0; x < data.length; x++) {
                markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
            }
            
            $("#specialitiesSelect").html(markup).show();
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}