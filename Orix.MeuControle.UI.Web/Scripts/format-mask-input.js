function addCalendarioMascara(inputClass,minDate) {
    $(inputClass).datepicker({
        dateFormat: 'dd/mm/yy',
        dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado'],
        dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
        monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        nextText: 'Próximo',
        prevText: 'Anterior'
    });
    $(inputClass).mask("99/99/9999", {});

    if (minDate) {
        $(inputClass).datepicker("option", "minDate", minDate);
    }
}


function setDateMin(url, inputClass) {
    $.ajax(
        {
            type: 'GET',
            url: url,
            dataType: 'json',
            cache: false,
            async: true,
            beforeSend: function () {
                
            },
            success: function (data) {
                $(inputClass).datepicker("option", "minDate", data.dataEmprestimo);
            },
            complete: function () {
                
            }
        });
}
