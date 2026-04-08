

$.validator.addMethod("bookname",
        function (value, element, param) {
            if (value == '') return false;
            if (value == 'EvanH') return false;
            return true;
        });

$.validator.unobtrusive.adapters.add("bookname", ["name"], function (options) {
    options.rules["bookname"] = options.params.name;
    options.messages["bookname"] = "Client Side Validation";
});

