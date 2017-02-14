function ExibirModalExcluirGenerico(codigo, url) {
    $('#ModalExcluirGenerico').attr('data-id', codigo);
    $('#ModalExcluirGenerico').attr('data-url', url);
    $('#ModalExcluirGenerico').modal('show');
};
function ExibirModalExcluir(codigo) {
    $('#ModalExcluir').attr('data-id', codigo);
    $('#ModalExcluir').modal('show');
};