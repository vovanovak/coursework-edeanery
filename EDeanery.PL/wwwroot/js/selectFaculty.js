function getCheckedFacultyIds() {
    var checkBoxes = $("#selectFacultiesTable").find(".facultyCheckBox");
    var facultyIds = [];
    for (var i = 0; i < checkBoxes.length; i++) if (checkBoxes[i].checked) {
        var facultyId = parseInt($(checkBoxes[i]).val());
        facultyIds.push(facultyId);
    }

    return facultyIds;
}