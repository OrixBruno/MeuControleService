var EmprestimosAjax = {
    Mensagem: function (mensagem) {
        $.ajax(
            {
                type: 'GET',
                url: '/ControleMapas/Emprestimo/Mensagem?mensagem=' + mensagem,
                dataType: "html",
                cache: false,
                async: true,
                success: function (data, status) {
                    $('#mensagem').html(data);
                }
            });
    },
    SelectMapasDisponiveis: function () {
        $.ajax(
            {
                type: 'GET',
                url: '/ControleMapas/Emprestimo/SelectMapasDisponiveis',
                dataType: "html",
                cache: false,
                async: true,
                success: function (data, status) {
                    $('#selectMapas').html(data);
                }
            });
    },
    SelectMapasDevolucao: function () {
        $.ajax(
            {
                type: 'GET',
                url: '/ControleMapas/Emprestimo/SelectMapasDevolucao',
                dataType: "html",
                cache: false,
                async: true,
                success: function (data, status) {
                    $('#selectMapas').html(data);
                }
            });
    },
    TemEmprestimo: function () {
        $.ajax(
            {
                type: 'GET',
                url: '/ControleMapas/Emprestimo/QtdMapaDisponivel',
                contentType: "application/json",
                dataType: "json",
                cache: false,
                async: true,
                beforeSend: function () {
                    $('#myModal').modal('show');
                },
                success: function (data, status) {
                    if (parseInt(data.qtdEmprestimos) < 1) {
                        $('#conteudoModal').html("Não existe empréstimo cadastrado no sistema! Contate o administrador para mais informações.");
                        $('#modalConfiguracao').modal('show');
                        $('#tituloFooter').text("Mapa error...");
                    }
                    EmprestimosAjax.Devolucao();
                },
                complete: function () {
                    $('#myModal').modal('hide');
                }
            });
    },
    MapaCadastrado: function () {
        $.ajax(
        {
            type: 'GET',
            url: '/ControleMapas/Emprestimo/QtdMapaDisponivel',
            contentType: "application/json",
            dataType: "json",
            cache: false,
            async: true,
            beforeSend: function () {
                $('#myModal').modal('show');
            },
            success: function (data, status) {
                if (parseInt(data.qtdMapaDisponivel) < 1) {
                    $('#conteudoModal').html("Não existe mapa disponivel para empréstimo no sistema! Contate o administrador para mais informações.");
                    $('#modalConfiguracao').modal('show');
                    $('#tituloFooter').text("Mapa error...");
                }
                EmprestimosAjax.Adicionar();
            },
            complete: function () {
                $('#myModal').modal('hide');
            }
        });
    },
    Devolucao: function () {
        $.ajax(
        {
            type: 'GET',
            url: '/ControleMapas/Emprestimo/FormularioDevolucao',
            dataType: 'html',
            cache: false,
            async: true,
            beforeSend: function () {
                $('#myModal').modal('show');
            },
            success: function (data) {
                $('#FrmDevolucao').html(data);
            },
            complete: function () {
                $('#myModal').modal('hide');
                EmprestimosAjax.SelectMapasDevolucao();
            }
        });
    },
    Adicionar: function () {
        $.ajax(
        {
            type: 'GET',
            url: '/ControleMapas/Emprestimo/FormularioAdicionar',
            dataType: 'html',
            cache: false,
            async: true,
            beforeSend: function () {
                $('#myModal').modal('show');
            },
            success: function (data) {
                $('#FrmAdicionar').html(data);
            },
            complete: function () {
                $('#myModal').modal('hide');
                EmprestimosAjax.SelectMapasDisponiveis();
            }
        });
    }
};

var ChamadasAjax = {
    id: "",
    ListaMapas: function (url) {
        $.ajax(
            {
                type: 'GET',
                url: url,
                dataType: 'html',
                cache: false,
                async: true,
                success: function (data) {
                    $('#ListaMapas').html(data);
                }
            });
    },
    ModalExcluir: function (codigo, url) {
        $.ajax({
            type: 'GET',
            url: url + codigo,
            async: true,
            cache: false,
            beforeSend: function () {

            },
            success: function (data) {
                $('#mensagem').html(data);
            },
            complete: function () {
                $('#ModalExcluirGenerico').modal('hide');
                $('#ListaMapas').html('');
                $('#conteudoLista').html('');
                ChamadasAjax.ListaMapas('/ControleMapas/Mapa/ListarAjax');
                CarregarListaEmprestimo();
            }
        });
    },
    Visualizar: function (url, titulo) {
        $.ajax(
            {
                type: 'GET',
                url: url,
                dataType: 'html',
                cache: false,
                async: true,
                beforeSend: function () {
                    $('#myModal').modal('show');
                },
                success: function (data) {
                    $('#tituloFooter').text(titulo);
                    $('#conteudoModal').html(data);
                    $('#modalConfiguracao').modal('show');
                },
                complete: function () {
                    $('#myModal').modal('hide');
                }
            });
    },

    Imagem: function (url) {
        var data = new FormData();
        var files = $("#uploadImage").get(0).files;
        if (files.length > 0) {
            data.append("Id", id);
            data.append("Imagem", files[0]);
        }
        $.ajax({
            url: url,
            type: "POST",
            processData: false,
            contentType: false,
            data: data,
            success: function (response) {

            },
            error: function (er) {

            }

        });
    },
    Adicionar: function (url) {
        $.ajax(
            {
                type: 'GET',
                url: url,
                dataType: 'html',
                cache: false,
                async: true,
                beforeSend: function () {
                    $('#myModal').modal('show');
                },
                success: function (data) {
                    $('#tituloFooter').text("Adicionando ...");
                    $('#conteudoModal').html(data);
                    $('#modalConfiguracao').modal('show');
                },
                complete: function () {
                    $('#myModal').modal('hide');
                }
            });
    },

    Excluir: function (url) {
        $.ajax({
            type: 'GET',
            url: url,
            async: true,
            cache: false,
            beforeSend: function () {
                $('#myModal').modal('show');
            },
            success: function (data) {
                $('#mensagem').html(data);
                ChamadasAjax.CarregarTabelas();
            },
            complete: function () {
                $('#myModal').modal('hide');
            }
        });
    },
    Editar: function (url) {
        $.ajax({
            type: 'GET',
            url: url,
            dataType: 'html',
            cache: false,
            async: true,
            beforeSend: function () {
                $('#myModal').modal('show');
            },
            success: function (data) {
                $('#tituloFooter').text("Adicionando ...");
                $('#conteudoModal').html(data);
                $('#modalConfiguracao').modal('show');
                ChamadasAjax.CarregarTabelas();
            },
            complete: function () {
                $('#myModal').modal('hide');
            }
        });
    },

    CarregarTabelas: function () {
        $.ajax(
            {
                type: 'GET',
                url: '/ControleMapas/Letra/Lista',
                dataType: 'html',
                cache: false,
                async: true,
                beforeSend: function () {
                    $('#myModal').modal('show');
                },
                success: function (data) {
                    $('#partialLetra').html(data);
                },
                complete: function () {
                    $('#myModal').modal('hide');
                }
            });

        $.ajax(
            {
                type: 'GET',
                url: '/ControleMapas/Saida/Lista',
                dataType: 'html',
                cache: false,
                async: true,
                beforeSend: function () {
                    $('#myModal').modal('show');
                },
                success: function (data) {
                    $('#partialSaida').html(data);
                },
                complete: function () {
                    $('#myModal').modal('hide');
                }
            });

        $.ajax(
            {
                type: 'GET',
                url: '/ControleMapas/Territorio/Lista',
                dataType: 'html',
                cache: false,
                async: true,
                beforeSend: function () {
                    $('#myModal').modal('show');
                },
                success: function (data) {
                    $('#partialTerritorio').html(data);
                },
                complete: function () {
                    $('#myModal').modal('hide');
                }
            });
    }
}

function ExcluirSurdo(codigo) {
    $.ajax({
        type: 'GET',
        url: '/ControleMapas/Surdo/Excluir/' + codigo,
        async: true,
        cache: false,
        beforeSend: function () {

        },
        success: function (data) {
            $('#mensagem').html(data);
            CarregarLista();
        },
        complete: function () {
            $('#ModalExcluir').modal('hide');
        }
    });
};
function CarregarLista() {
    $.ajax(
    {
        type: 'GET',
        url: '/ControleMapas/Surdo/ObterListaSurdosPagina',
        dataType: 'html',
        cache: false,
        async: true,
        beforeSend: function () {
            $('#myModal').modal('show');
        },
        success: function (data) {
            $('#conteudoLista').html(data);
        },
        complete: function () {
            $('#myModal').modal('hide');
            SurdosTotal();
        }
    });
};
function Ordenar(coluna) {
    $.ajax(
    {
        type: 'GET',
        url: '/ControleMapas/Surdo/ObterListaSurdosPagina?coluna=' + coluna + '&nome=' + $('#nomeBuscar').val() + '&page=',
        dataType: 'html',
        cache: false,
        async: true,
        beforeSend: function () {
            $('#myModal').modal('show');
        },
        success: function (data) {
            $('#conteudoLista').html(data);
        },
        complete: function () {
            $('#myModal').modal('hide');
            SurdosTotal();
        }
    });
};
function SurdosTotal() {
    $.ajax({
        type: 'GET',
        url: 'http://projetos.serveftp.com:81/api/v1/Surdo/SurdosTotal',
        cache: false,
        async: true,
        dataType: 'html',
        success: function (data) {
            $('#surdoTotal').text(data);
        }
    });
}