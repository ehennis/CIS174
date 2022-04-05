

    $.validator.addMethod("moviefirstname",
        function (value, element, param) {
            if (value == '') return false;
            if (value == 'EvanH') return false;
            return true;
        });

    //$.validator.unobtrusive.adapters.add("moviefirstname","name");

$.validator.unobtrusive.adapters.add("moviefirstname", ["name"], function (options) {
    options.rules["moviefirstname"] = options.params.name;
    options.messages["moviefirstname"] = "Client Side Validation";
});

