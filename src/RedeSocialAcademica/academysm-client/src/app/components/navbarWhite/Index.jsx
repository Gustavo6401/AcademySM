import React from 'react';
import './Index.css'
import Grupos from '../../pages/grupos/Index';

function NavbarWhite() {
    return (
        <nav className='navbar-white'>
            <div>
                <a className='nav-white-link inika' href='#'>Academy SM</a>
                <div className='navbar-toggle' id='menuToggle'>
                    <div className='nav-white-toggle-item'></div>
                    <div className='nav-white-toggle-item'></div>
                    <div className='nav-white-toggle-item'></div>
                </div>
            </div>
            <ul className='barra-navegacao-branca closed' id='menu'>
                <li className='navbar-li'>
                    <a className='nav-white-link' href='#'>Home</a>
                </li>
                <li className='navbar-li'>
                    <a className='nav-white-link' href='#'>Artigos</a>
                </li>
                <li className='navbar-li'>
                    <a className='nav-white-link' href='/Grupos'>Grupos</a>
                </li>
                <li className='navbar-li'>
                    <a className='nav-white-link' href='#'>Dúvidas</a>
                </li>
            </ul>
        </nav>
    );
}

export default NavbarWhite;