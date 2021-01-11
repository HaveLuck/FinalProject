function editorUploadFile(file) {
    // bat loading
    debugger;
    $('.overload-wait').removeClass('hide');

    var urlRlt = '';
    data = new FormData();
    data.append("file", file);
    $.ajax({
        data: data,
        type: "POST",
        url: "/news/EditorUpload.ashx",
        cache: false,
        contentType: false,
        processData: false,
        success: function (dataResult) {
            ////debugger;
            if (dataResult == 'Invalid access!') {
                alert('Không thể upload file do phiên làm việc của bạn đã hết.\nVui lòng đăng nhập lại.');
            }
            else if (dataResult == 'ERROR_PATH') {
                alert("ERROR: " + dataResult + "Lỗi không tìm thấy folder");
            }
            else {
                if (dataResult.length > 0) {
                    var lstFile = $.parseJSON(dataResult);
                    urlRlt = lstFile[0].url;
                }
            }
        },
        error: function (dataErr) {
            ////debugger;
            alert(dataErr);
            $('.overload-wait').addClass('hide');
        },
        async: false
    });
    // tắt loading
    $('.overload-wait').addClass('hide');
    return urlRlt;
}