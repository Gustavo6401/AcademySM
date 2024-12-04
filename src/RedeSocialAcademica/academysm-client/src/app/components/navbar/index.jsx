import React from 'react';
import '../navbar/Index.css';
import navigateTo from '../../../infra/navigation/navigation';

/**
 * @param {string} url
 */
function navigate(url) {
    navigateTo(url)
}

export default function Navbar() {
    return (
        <nav className='navbar-mine'>
            <div>
                <a className='nav-mine-link inika' href='#'>Academy SM</a>
                <div className='navbar-toggle' id='menuToggle'>
                    <div className='nav-toggle-item'></div>
                    <div className='nav-toggle-item'></div>
                    <div className='nav-toggle-item'></div>
                </div>
            </div>
            <ul className='barra-navegacao closed' id='menu'>
                <li className='navbar-li' onClick={() => navigate('/')}>
                    <a className='nav-mine-link' href='/'>Home</a>
                </li>
                <li className='navbar-li' onClick={() => navigate('/Grupos')}>
                    <a className='nav-mine-link' href='/Grupos'>Grupos</a>
                </li>
                <li className='navbar-li' onClick={() => navigate('/Login')}>
                    <a className='nav-mine-link' href='/Login'>Login</a>
                </li>
                <li className='navbar-li' onClick={() => navigate('/CadastroDeUsuario')}>
                    <a className='nav-mine-link' href='/CadastroDeUsuario'>Cadastro</a>
                </li>
            </ul>
        </nav>
    );
}
