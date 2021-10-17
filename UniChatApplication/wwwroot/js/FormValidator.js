// Obj `Validator`
function Validator(options) {
  function getParent(element, selector) {
    while (element.parentElement) {
      if (element.parentElement.matches(selector)) {
        return element.parentElement;
      }
      element = element.parentElement;
    }
  }

  var selectorRules = {};

  // Function that performs validation
  function validate(inputElement, rule) {
    var errorElement = getParent(
      inputElement,
      options.formGroupSelector
    ).querySelector(options.errorSelector);
    var errorMessage;

    // Get selector rules
    var rules = selectorRules[rule.selector];

    // Loop through each rule & check
    // If there is an error, stop checking
    for (var i = 0; i < rules.length; ++i) {
      switch (inputElement.type) {
        case "radio":
        case "checkbox":
          errorMessage = rules[i](
            formElement.querySelector(rule.selector + ":checked")
          );
          break;
        default:
          errorMessage = rules[i](inputElement.value);
      }
      if (errorMessage) break;
    }

    if (errorMessage) {
      errorElement.innerText = errorMessage;
      getParent(inputElement, options.formGroupSelector).classList.add(
        "invalid"
      );
    } else {
      errorElement.innerText = "";
      getParent(inputElement, options.formGroupSelector).classList.remove(
        "invalid"
      );
    }

    return !errorMessage;
  }

  // Get the element of the form to be validated
  var formElement = document.querySelector(options.form);
  if (formElement) {
    // When submitting the form
    formElement.onsubmit = function (e) {
      e.preventDefault();

      var isFormValid = true;

      // Loop through each rule and validate
      options.rules.forEach(function (rule) {
        var inputElement = formElement.querySelector(rule.selector);
        var isValid = validate(inputElement, rule);
        if (!isValid) {
          isFormValid = false;
        }
      });

      if (isFormValid) {
        // The case of submitting with javascript
        if (typeof options.onSubmit === "function") {
          var enableInputs = formElement.querySelectorAll("[name]");
          var formValues = Array.from(enableInputs).reduce(function (
            values,
            input
          ) {
            switch (input.type) {
              case "radio":
                values[input.name] = formElement.querySelector(
                  'input[name="' + input.name + '"]:checked'
                ).value;
                break;
              case "checkbox":
                if (!input.matches(":checked")) {
                  values[input.name] = "";
                  return values;
                }
                if (!Array.isArray(values[input.name])) {
                  values[input.name] = [];
                }
                values[input.name].push(input.value);
                break;
              case "file":
                values[input.name] = input.files;
                break;
              default:
                values[input.name] = input.value;
            }

            return values;
          },
            {});
          options.onSubmit(formValues);
        }
        // Submit case with default behavior
        else {
          formElement.submit();
        }
      }
    };

    // Loop through each rule and process (listen for blur, input, ...)
    options.rules.forEach(function (rule) {
      // Save the rules for each input
      if (Array.isArray(selectorRules[rule.selector])) {
        selectorRules[rule.selector].push(rule.test);
      } else {
        selectorRules[rule.selector] = [rule.test];
      }

      var inputElements = formElement.querySelectorAll(rule.selector);

      Array.from(inputElements).forEach(function (inputElement) {
        // Handle blur from input
        inputElement.onblur = function () {
          validate(inputElement, rule);
        };

        // Handle every time the user enters input
        inputElement.oninput = function () {
          var errorElement = getParent(
            inputElement,
            options.formGroupSelector
          ).querySelector(options.errorSelector);
          errorElement.innerText = "";
          getParent(inputElement, options.formGroupSelector).classList.remove(
            "invalid"
          );
        };
      });
    });
  }
}

// Definition of rules
// Principle of the rules:
// 1. When there is an error => Return error message
// 2. When valid => Returns nothing (undefined)
Validator.isRequired = function (selector, message) {
  return {
    selector: selector,
    test: function (value) {
      return value ? undefined : message || "Input can not be blank!";
    },
  };
};

// Check email with the extension @fpt.edu.vn
Validator.isEmail = function (selector, message) {
  return {
    selector: selector,
    test: function (value) {
      var regex = /^\w+([\.-]?\w+)*@*(fpt\.edu\.vn)+$/;

      return regex.test(value)
        ? undefined
        : message || "Please correct email format: email@fpt.edu.vn";
    },
  };
};

// check Student code consists of 2 letters + 6 digits
Validator.isStuCode = function (selector, message) {
  return {
    selector: selector,
    test: function (value) {
      var regex = /^[a-zA-Z]{2}(\d{6})$/;

      return regex.test(value)
        ? undefined
        : message ||
        "Please only enter in the standard form: 2 letters + 6 digits";
    },
  };
};

// check teacher code contains 8 digits
Validator.isTeacherCode = function (selector, message) {
  return {
    selector: selector,
    test: function (value) {
      var regex = /^(\d{8})$/;

      return regex.test(value)
        ? undefined
        : message || "Please enter only 8 digits!";
    },
  };
};

// Full name contains only letters
Validator.isName = function (selector, message) {
  return {
    selector: selector,
    test: function (value) {
      var regex = /^[^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$/;

      return regex.test(value)
        ? undefined
        : message || "Please enter only letters";
    },
  };
};

// Class has the first 2 characters as letters and the last 4 characters as numbers 0-9
Validator.isNameClass = function (selector, message) {
  return {
    selector: selector,
    test: function (value) {
      var regex = /^[a-zA-Z]{2}[0-9]{4}$/;

      return regex.test(value)
        ? undefined
        : message || "Please only enter in the standard form: 2 letters + 4 digits";
    },
  };
};

// Subject code has the first 3 characters as letters and the last 3 characters as numbers 0-9
Validator.isSubCode = function (selector, message) {
  return {
    selector: selector,
    test: function (value) {
      var regex = /^[a-zA-Z]{3}[0-9]{3}$/;

      return regex.test(value)
        ? undefined
        : message || "Please only enter in the standard form: 3 letters + 3 digits";
    },
  };
};

// check input has the correct number of characters according to the input parameter
Validator.minLength = function (selector, min, message) {
  return {
    selector: selector,
    test: function (value) {
      return value.length == min
        ? undefined
        : message || `Please enter only ${min} characters`;
    },
  };
};

// limit the number of characters for input
Validator.maxLength = function (selector, max, message) {
  return {
    selector: selector,
    test: function (value) {
      return value.length <= max
        ? undefined
        : message || `Please enter max ${max} characters`;
    },
  };
};

// confirm the input value again
Validator.isConfirmed = function (selector, getConfirmValue, message) {
  return {
    selector: selector,
    test: function (value) {
      return value === getConfirmValue()
        ? undefined
        : message || "Giá trị nhập vào không chính xác";
    },
  };
};
