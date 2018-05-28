function deleteStudent(studentId) {
    $.ajax({
        url: "/Student/DeleteStudent?studentId=" + studentId,
        type: "DELETE",
        success: function (data) {
            console.log("Ok");
        },
        error: function (reponse) {
            alert("error : " + reponse);
        }
    });
}