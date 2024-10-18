export default function CopyContent() {
    var passwordGeneratorInput = document.getElementById('passwordGeneratorInput')
    var copyButton = document.getElementById('copyButton')
    
    navigator.clipboard.writeText(passwordGeneratorInput.value)
        .then(() => {
            copyButton.textContent = 'Copiado!'
        })
        .catch((err) => {
            console.error(`Ocorreu um erro! ${err}`)
        })
}