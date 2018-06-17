function onFindStudents() {
    var searchQuery = $("#searchQuery").val();
    var searchType = $("#searchType :selected").text();
    var searchUrl;

    switch (searchType) {
        case "Full name":
            searchUrl = "/Student/GetStudentsByFullName?search=" + searchQuery;
            break;
        case "Group":
            searchUrl = "/Student/GetStudentsByGroup?search=" + searchQuery;
            break;
    }

    if (typeof groupId !== 'undefined')
        searchUrl += "&groupId=" + groupId;
    if (typeof dormitoryId !== 'undefined')
        searchUrl += "&dormitoryId=" + dormitoryId;
    if (typeof dormitoryRoomId !== 'undefined')
        searchUrl += "&dormitoryRoomId=" + dormitoryRoomId;
    
    $.ajax({
        url: searchUrl,
        type: "GET",
        success: function (data) {
            var html = "";
            for (var i = 0; i < data.length; i++) {
                html += "<tr>";
                html += "<td><a href='/Student/GetStudentById?studentId=" + data[i].studentId + "'>" + data[i].fullName + "</a></td>";
                html += "<td>" + data[i].email + "</td>";
                html += "<td>" + data[i].phoneNumber + "</td>";
                html += "<td>" + data[i].identificationCode + "</td>";
                html += "<td>" + data[i].birthDate + "</td>";
                html += "<td>" + data[i].passportIdentifier + "</td>";
                html += "<td>" + data[i].studentTicket + "</td>";
                html += "<td>" + data[i].facultyName + "</td>";
                html += "</tr>";
            }
            $("#studentsTable tbody").html(html);
        },
        error: function (response) {
            console.log(response);
        }
    });
}