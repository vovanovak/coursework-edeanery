function getCheckedStudentIds() {
    var checkBoxes = $("#selectStudentsTable").find(".studentCheckBox");
    var studentIds = [];
    for (var i = 0; i < checkBoxes.length; i++) if (checkBoxes[i].checked) {
        var studentId = parseInt($(checkBoxes[i]).val());
        studentIds.push(studentId);
    }

    return studentIds;
}