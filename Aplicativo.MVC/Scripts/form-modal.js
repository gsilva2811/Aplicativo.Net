
$(document).on("click", ".item-modal", function (e) {
    e.preventDefault();
    var editarLink = $(this).attr("href");
    $.get(editarLink, { key: $.now() }, function (retorno) {

        $("#acao").html(retorno);
        var modal = $('#acao div.modal');
        modal.modal('show');
        var form = modal.find('form');

        modal.find('.btn-primary').click(function () {
            $(this).attr('disabled', 'disabled');
            form.submit();
            modal.modal("hide");
        });


        form.submit(function () {
            $.post(this.action, $(this).serialize(), function (lista) {
                $('#lista').html(lista);
            });
            return false;
        });
    });
});
