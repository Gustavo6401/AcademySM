import React from 'react';
import '../navbar/Index.css';

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
                <li className='navbar-li'>
                    <a className='nav-mine-link' href='#'>Home</a>
                </li>
                <li className='navbar-li'>
                    <a className='nav-mine-link' href='#'>Artigos</a>
                </li>
                <li className='navbar-li'>
                    <a className='nav-mine-link' href='/Grupos'>Grupos</a>
                </li>
                <li className='navbar-li'>
                    <a className='nav-mine-link' href='#'>Dúvidas</a>
                </li>
            </ul>
        </nav>
    );
}
