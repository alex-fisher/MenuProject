var EMAIL = {
    runtime: {
        file: '',
        sendEmailLink: ''
    },
    init: function () {

        $("#submit").off().on('click', function () {
            if (EMAIL.runtime.file == '') {
                $("#fileError").text("Please select a file");
                return false;
            }
            EMAIL.ajax.upload();
        });

        $("#fileSelect").on('change', function (e) {

            $("#fileError").text("");

            // fetch FileList object
            var files = e.target.files;

            if (files.length == 0) {
                $("#fileInfo").text("No File Chosen");
                EMAIL.runtime.file = '';
                return;
            }

            // process all File objects
            for (var i = 0, f; f = files[i]; i++) {
                EMAIL.files.validate(f);
                var fileName = f.name;
                if (fileName.length > 20) {
                    fileName = fileName.substring(0, 20) + "...";
                }
                $('#fileInfo').html(fileName);
            }
            e.preventDefault();
            e.stopPropagation();
            return false;
        });
    },
    files: {
        validate: function (file) {           
            var reader = new FileReader();
            reader.onload = function () {
                if (file.size > 1000000) {
                    $("#fileError").text("File may not exceed 1 MB in size");
                    return false;
                }

                var nameParts = file.name.split(".");
                if (nameParts.length < 2 || nameParts[1] != 'json') {
                    $("#fileError").text("File must be of type json");
                    return false;
                }

                EMAIL.runtime.file = file;
            };

            reader.readAsDataURL(file);
        }
    },
    html: {
        renderResponse: function (response) {
            if (response && response.result instanceof Array) {
                var html = '';
                var menus = response.result;
                for (var i = 0; i < menus.length; i++) {
                    var menuRoot = menus[i];
                    html += '<div>' + menuRoot.sum + '</div>';
                }
                $("#results").html(html);
            }
        },
        setUploading: function (sending) {
            $("#uploading").removeClass("fa-times-circle").css("color", "black");
            $("#uploading").removeClass("fa-check").addClass("fa-refresh").addClass("fa-spin");
            if (sending) {
                $("#uploading").removeClass("invisible");
            } else {
                $("#uploading").addClass("invisible");
            }
        },
        setUploaded: function () {
            $("#uploading").removeClass("fa-refresh").removeClass("fa-spin").addClass("fa-check").css("color", "green");
        },
        setFailed: function () {
            $("#uploading").removeClass("fa-refresh").removeClass("fa-spin").addClass("fa-times-circle").css("color", "red");
        }
    },
    ajax: {
        upload: function () {
            EMAIL.html.setUploading(true);
            var formData = new FormData();
            formData.append("FileUpload", EMAIL.runtime.file);
            $("#fileError").text("");
            $.ajax({
                url: "/Menu/upload",
                data: formData,
                type: "post",
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response && response.status) {
                        EMAIL.html.setUploaded();
                        EMAIL.html.renderResponse(response);
                    } else {
                        EMAIL.html.setFailed();
                        $("#fileError").text(response.error);
                    }
                },
                error: function (err) {
                    EMAIL.html.setFailed();
                    $("#fileError").text("Error Uploading File");
                }
            });
            return false;
        }
    }
};