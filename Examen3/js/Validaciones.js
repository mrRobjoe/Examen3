function soloNumeros(e) {
    Key = e.KeyCode || e.which;
    teclado = String.fromCharCode(Key);
    numero = "0123456789";
    especiales = "8-37-38-46";
    teclado_especial = false;
    for (var i in especiales) {
        if (Key == especiales[i]) {
            teclado_especial = true;
        }
    }

    if (numero.indexOf(teclado)==-1 && !teclado_especial){
        return false;
    }

}