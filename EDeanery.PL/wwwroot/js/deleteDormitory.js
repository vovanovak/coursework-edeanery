function deleteDormitory(dormitoryId) {
    $.ajax({
        url: "/Dormitory/DeleteDormitory?dormitoryId=" + dormitoryId,
        type: "DELETE",
        success: function (data) {
            console.log("Ok");
        },
        error: function (response) {
            console.log(response);
        }
    });
}