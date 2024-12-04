import NavbarWhite from '../../components/navbarWhite/Index.jsx'
import logo from '../../assets/image/Academy SM.png'
import '../login/Index.css'
import { useState } from 'react';
import LoginViewServices from '../../services/loginViewServices.js';
import navigateTo from '../../../infra/navigation/navigation.js';

function Login() {
    const[email, setEmail] = useState<string>('')
    const[password, setPassword] = useState<string>('')

    var services: LoginViewServices = new LoginViewServices()

    const logar = async () => {
        const resultado = await services.login(email, password)

        alert(resultado)
    }

    const cadastroDeUsuario = () => {
        navigateTo('/CadastroDeUsuario')
    }

    return (
        <div>
            <NavbarWhite />
            <div className='alinhadoEsquerda'>
                <div className='login'>
                    <div className='componentIsolator-1'>
                        <img className='imagemQuadrada-logoAcademySM' src={logo} />
                    </div>
                    <div className='componentIsolator-1'>
                        <input className='formInputType-2' type='email' placeholder='E-Mail' onChange={e => setEmail(e.target.value)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <input className='formInputType-2' type='password' placeholder='Senha' onChange={e => setPassword(e.target.value)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <button className='medium branco'>Esqueceu Sua Senha?</button>
                    </div>
                    <div className='componentIsolator-1'>
                        <button className='medium azul-escuro' onClick={logar}>Login</button>
                    </div>
                    <div className='componentIsolator-1'>
                        <button className='medium preto' onClick={cadastroDeUsuario}>Cadastre-se</button>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Login;