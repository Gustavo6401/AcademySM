import React from 'react';
import './Index.css'
import Grupos from '../../pages/grupos/Index';
import navigateTo from '../../../infra/navigation/navigation';

/**
 * @param {string} url
 */
function navigate(url) {
    navigateTo(url)
}

function NavbarWhite() {
    return (
        <nav className='navbar-white'>
            <div>
                <a className='nav-white-link inika' href='/'>Academy SM</a>
                <div className='navbar-toggle' id='menuToggle'>
                    <div className='nav-white-toggle-item'></div>
                    <div className='nav-white-toggle-item'></div>
                    <div className='nav-white-toggle-item'></div>
                </div>
            </div>
            <ul className='barra-navegacao-branca closed' id='menu'>
                <li className='navbar-li' onClick={() => navigate('/')}>
                    <a className='nav-white-link' href='/'>Home</a>
                </li>
                <li className='navbar-li' onClick={() => navigate('/Grupos')}>
                    <a className='nav-white-link' href='/Grupos'>Grupos</a>
                </li>
                <li className='navbar-li' onClick={() => navigate('/Login')}>
                    <a className='nav-white-link' href='/Login'>Login</a>
                </li>
                <li className='navbar-li' onClick={() => navigate('/CadastroDeUsuario')}>
                    <a className='nav-white-link' href='/CadastroDeUsuario'>Cadastro de Usuário</a>
                </li>
            </ul>
        </nav>
    );
}

export default NavbarWhite;