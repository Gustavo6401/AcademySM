export default function ButtonClickGeneratePassword() {
    /** @type {boolean} */
    var isValid = false
    /** @type {string} */
    var password = ''

    // This is responsible for checking whether the password is really valid. If this is valid, we will continue.
    while (isValid === false) {
        password = generatePassword()

        isValid = passwordValidator(password)
    }    

    var input = document.getElementById('passwordGeneratorInput')
    input.value = password
}