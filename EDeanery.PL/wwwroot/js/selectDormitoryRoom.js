function getCheckedDormitoryRoomIds() {
    var checkBoxes = $("#selectDormitoryRoomsTable").find(".dormitoryRoomCheckBox");
    var dormitoryRoomIds = [];
    for (var i = 0; i < checkBoxes.length; i++) if (checkBoxes[i].checked) {
        var dormitoryRoomId = parseInt($(checkBoxes[i]).val());
        dormitoryRoomIds.push(dormitoryRoomId);
    }

    return dormitoryRoomIds;
}