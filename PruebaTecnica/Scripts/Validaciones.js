document.addEventListener("DOMContentLoaded", function () {
    const form = document.querySelector("form");
    const nombreUsuario = document.getElementById("NombreUsuario");
    const nombre = document.getElementById("Nombre");
    const apellidos = document.getElementById("Apellidos");
    const correo = document.getElementById("Correo");

    const soloLetrasRegex = /^[A-Za-z¡…Õ”⁄—·ÈÌÛ˙Ò\s]+$/;
    const usuarioValidoRegex = /^(?=.*[A-Za-z])[A-Za-z0-9]+$/;

    form.addEventListener("submit", function (e) {
        let errores = [];

        if (nombreUsuario.value.trim() === "") {
            errores.push("El campo 'Nombre de usuario' es obligatorio.");
        } else if (nombreUsuario.value.trim().length < 3) {
            errores.push("El 'Nombre de usuario' debe tener al menos 3 caracteres.");
        } else if (!usuarioValidoRegex.test(nombreUsuario.value.trim())) {
            errores.push("El 'Nombre de usuario' debe contener solo letras y numeros, y no puede ser solo numeros.");
        }

        if (nombre.value.trim() === "") {
            errores.push("El campo 'Nombre' es obligatorio.");
        } else if (nombre.value.trim().length < 3) {
            errores.push("El 'Nombre' debe tener al menos 3 caracteres.");
        } else if (!soloLetrasRegex.test(nombre.value.trim())) {
            errores.push("El campo 'Nombre' solo debe contener letras.");
        }

        if (apellidos.value.trim() === "") {
            errores.push("El campo 'Apellidos' es obligatorio.");
        } else if (apellidos.value.trim().length < 3) {
            errores.push("Los 'Apellidos' deben tener al menos 3 caracteres.");
        } else if (!soloLetrasRegex.test(apellidos.value.trim())) {
            errores.push("El campo 'Apellidos' solo debe contener letras.");
        }

        if (correo.value.trim() === "") {
            errores.push("El campo 'Email' es obligatorio.");
        } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(correo.value)) {
            errores.push("El correo electrÛnico no tiene un formato v·lido.");
        }

        if (errores.length > 0) {
            e.preventDefault();
            alert(errores.join("\n"));
        }
    });
});
