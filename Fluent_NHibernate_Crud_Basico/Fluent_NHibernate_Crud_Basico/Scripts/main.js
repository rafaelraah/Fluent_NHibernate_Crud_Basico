//Os dois métodos abaixo tem a função de bloquear a entrada do caracter 'E' nos campos númericos.

function FilterInput(event) {
    var keyCode = ('which' in event) ? event.which : event.keyCode;

    isNotWanted = (keyCode == 69 || keyCode == 101);
    return !isNotWanted;
};

function handlePaste(e) {
    var clipboardData, pastedData;

    // Get pasted data via clipboard API
    clipboardData = e.clipboardData || window.clipboardData;
    pastedData = clipboardData.getData('Text').toUpperCase();

    if (pastedData.indexOf('E') > -1) {
        //alert('found an E');
        e.stopPropagation();
        e.preventDefault();
    }
};