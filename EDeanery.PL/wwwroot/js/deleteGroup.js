function deleteGroup(groupId) {
    $.ajax({
        url: "/Group/DeleteGroup?groupId=" + groupId,
        type: "DELETE",
        success: function (data) {
            console.log("Ok");
        },
        error: function (response) {
            console.log(response);
        }
    });
}