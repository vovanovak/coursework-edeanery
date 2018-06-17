function setSpecialtiesByFacultyId(facultyId) {
    $.ajax({
        url: "/Speciality/GetSpecialitiesByFacultyId/" + facultyId,
        type: "GET",
        success: function (data) {
            var markup = "";
            
            for (var x = 0; x < data.length; x++) {
                markup += "<option value=" + data[x].value + ">" + data[x].text + "</option>";
            }

            $("#specialitiesSelect").html(markup).show();
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}