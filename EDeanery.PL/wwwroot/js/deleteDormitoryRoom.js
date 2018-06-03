function deleteDormitoryRoom(dormitoryRoomId) {
    $.ajax({
        url: "/Dormitory/DeleteDormitoryRoom?dormitoryId=" + dormitoryRoomId,
        type: "DELETE",
        success: function (data) {
            console.log("Ok");
        },
        error: function (response) {
            console.log(response);
        }
    });
}