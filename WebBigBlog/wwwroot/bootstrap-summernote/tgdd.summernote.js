var fileSizeAllowUpload = 1;
var isAutoLoadEditor = true;
var isAllowLoadEditor = '1';

$(document).ready(function () {
    // load editor
    ////debugger;
    if (isAllowLoadEditor == '1') {
        $('.bcnbEditor').each(function () {
            ////debugger;
            var dataCtrlId = $(this).attr('data-val');
            var editCtrlId = $(this).attr('id');
            SetValueForEditor(editCtrlId, dataCtrlId)
        });
        LoadValueForEditor();
        //LoadValueForEditor();
    }

    // Bat su kien paste de check link clickable
    $('.note-editable').on('paste', function (e) {
        debugger;
        var data = e.originalEvent.clipboardData.getData('text');

        if (data.indexOf('http') > -1 & data.indexOf('http') < 4) {
            var begin = data.indexOf('http');
            var url = '';
            for (var i = begin; i < data.length; i++) {
                if (data[i] == ' ')
                    break;

                url += data[i];
            }

            data = data.replace(url, '<a target="_blank" href="' + url + '" >' + url + '</a>');

            e.preventDefault();
            window.document.execCommand('insertHTML', false, data);
        }
        else if (data.indexOf('www') > -1 & data.indexOf('www') < 4) {
            var begin = data.indexOf('www');
            var url = '';
            for (var i = begin; i < data.length; i++) {
                if (data[i] == ' ')
                    break;

                url += data[i];
            }

            data = data.replace(url, '<a target="_blank" href="' + url + '" >' + url + '</a>');

            e.preventDefault();
            window.document.execCommand('insertHTML', false, data);
        }
    });
});

function LoadEditor(pnlId, ctrlValueControl) {
    debugger;
    if (isAllowLoadEditor == '0') {
        return;
    }
    $('#' + pnlId).summernote({
        height: 300,
        lang: 'vi-VN',
        focus: false,
        resizebar: false,
        toolbar: [
                ['style', ['style']],
                ['font', ['fontname']],
                ['fontsize', ['fontsize']],
                ['style', ['bold', 'italic', 'underline']],
                ['color', ['color']],
                ['para', ['ul', 'ol', 'paragraph']],
                ['insert', ['picture', 'link', 'table', 'video']],
                ['misc', ['undo', 'redo']],
        ]
    });
    SetValueForEditor(pnlId, ctrlValueControl);
}

function SetValueForEditor(editorId, ctrlValueControlId) {
    ////debugger;
    var temp = $('#' + ctrlValueControlId).val();
    $('#' + editorId).code(temp);
}

function LoadValueForEditor() {
    ////debugger;
    var temp = $('#' + hdContent).val();
    $('#bcnbEditor').code(temp);
}

function GetValueForEditor() {
    //debugger;
    var html = $('#bcnbEditor').code();
    $('#' + hdContent).val(html);
}

function GetAllEditorContent() {
    $('.bcnbEditor').each(function () {
        //debugger;
        var dataCtrlId = $(this).attr('data-val');
        var editCtrlId = $(this).attr('id');

        var html = $('#' + editCtrlId).code();
        $('#' + dataCtrlId).val(html);
    });
}

function editorUploadFile(file) {
    // bat loading
    $('.overload-wait').removeClass('hide');

    var urlRlt = '';
    data = new FormData();
    data.append("file", file);
    $.ajax({
        data: data,
        type: "POST",
        url: "/EditorUpload.ashx",
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
function GetContentByID(editorId, ctrlValueID) {
    var html = $('#' + editorId).code();
    $('#' + ctrlValueID).val(html);
}