$(document).ready(function () {

    AddAntiForgeryToken = function (data) {
        data.__RequestVerificationToken = $('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val();
        return data;
    };

    $("#addAuthor").click(function () {
        var $buttonClicked = $(this);
        var addAuthorPostBackURL = $buttonClicked.attr('data-url');        
        $.ajax({
            type: "GET",
            url: addAuthorPostBackURL,
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            success: function (data) {
                $('#myModalContent').html(data);
                $('#myModal').modal('show');

                $("#saveAuthor").on("click", function (e) {
                    e.preventDefault();
                    var $buttonClicked = $(this);
                    var saveAuthorPostBackURL = $buttonClicked.attr('data-url');
                    var form = $("#editAuthorForm");
                    var dataArray = form.serializeArray();                    
                    var token = $('input[name="__RequestVerificationToken"]', form).val();
                    dataArray.__RequestVerificationToken = token;
                    $.ajax({
                        type: "POST",
                        url: saveAuthorPostBackURL,
                        data: dataArray,
                        success: function (id) {                         
                            $.ajax({
                                type: "GET",
                                url: "/BooksOfMyLife/Author/GetAllAuthors",
                                contentType: "application/json; charset=utf-8",
                                data: "{}",
                                datatype: "json",
                                success: function (data) {
                                    var ddlAuthors = $("[id*=ddl_Authors]");
                                    ddlAuthors.empty();
                                    $.each(data, function () {
                                        ddlAuthors.append($("<option />").val(this.Id).text(this.FirstName + " " + this.LastName));
                                    });
                                    ddlAuthors.val(id);
                                    $('#myModal').modal('hide');
                                },
                                error: function () {
                                    alert("Dynamic content load failed.");
                                }
                            });
                        }
                    });                    
                });
            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });

    $(".markBooksAsRead").on("click", function (e) {
        e.preventDefault();
        var $linkClicked = $(this);
        var bookId = $linkClicked.attr('data-id');
        var url = $linkClicked.attr('href');
        $.ajax({
            type: "POST",
            url: url,
            data: {bookId: bookId },
            success: function (resultData) {
                $linkClicked.find('img').removeClass("notRead");
            }
        });
    });

    $("#genreSelection").on("change", function (e) {
        var value = $(this).val();
        console.log(value);
    });
});