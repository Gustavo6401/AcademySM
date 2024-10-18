import Navbar from '../../components/navbar/index.jsx'
import '../passwordGenerator/Index.css'
import passwordValidator from '../../../domain/services/passwordValidator/ValidatePassword'
import CopyContent from './copyContent.js'
import ButtonClickGeneratePassword from './buttonClickGeneratePassword.js'

function generatePassword(): string {
    var lower: string = "abcdefghijklmnopqrstuvwxyz"
    var upper: string = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'
    var numbers: string = '0123456789'
    var symbol: string = '!@#$%¨&*()£¢¬/?°\\|\":;.,><^~`´}]º{{ª=+§-_\''

    var total: string = lower + upper + numbers + symbol
    var length: number = 32

    var senha: string = ''

    for (let i: number = 0; i <= length; i++) {
        var randomIndex: number = Math.floor(Math.random() * total.length)
        senha += total[randomIndex]
    }

    return senha
}

function PasswordGenerator() {
    return (
        <div>
            <Navbar />
            <div className='centralizador'>
                <main className='password-generator'>
                    <h1>Gere Aqui a Sua Senha.</h1>
                    <div className='align-components componentIsolator-1'>
                        <div className='componentIsolator-1'>
                            <input className='formInputType-1' type='text' id='passwordGeneratorInput' disabled />
                        </div>
                        <div className='componentIsolator-1'>
                            <button className='button-medium vermelho' id='copyButton' onClick={CopyContent}>Copiar</button>
                        </div>                        
                    </div>
                    <div className='componentIsolator-1'>
                        <button className='button-xlarge vermelho' onClick={ButtonClickGeneratePassword}>Gerar Senha</button>
                    </div>
                    <div className='componentIsolator-2'>
                        <button className='button-large azul-escuro'>Voltar à Tela de Cadastro.</button>
                    </div>
                </main>
            </div>
        </div>
    );
}

export default PasswordGenerator;