
$("#projectCode").keyup(function () {

    let charCount = $('#projectCode').val().length;
    
if (charCount >= 5) {
    runHTTPRequest()
}
})
    
function runHTTPRequest() {
    $.post('@Url.Action("IsProjectAvail", "Projects")',
        {
            projectCode: $("#projectCode").val()
        },
        function (data) {
            if (data == 0) {
                $("#projectCodeAvailability").html("<small class=\"text-success\"><strong>Project is available.</strong></small>");
            } else {
                $("#projectCodeAvailability").html("<small class=\"text-danger\"><strong>Project is not available.</strong></small>");
            }
        })
}
    