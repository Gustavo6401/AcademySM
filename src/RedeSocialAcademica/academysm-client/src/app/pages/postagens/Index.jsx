import React from 'react';
import Navbar from '../../components/navbar/index'
import foto from '../../assets/image/foto_gustavo.webp'
import grupoAbaArtigos from '../../assets/image/Grupo - Aba Artigos.png'
import './Index.css'
import GroupsNavbar from '../../components/groupsNavbar/Index';
import GroupDescription from '../../components/groupDescription/Index';

export default function PostagensGroups() {
    return (
        <div>
            <Navbar />
            <div className='groupsHomePage'>
                <main className='groups-index'>
                    <GroupDescription icon='bi bi-music-note-beamed' courseTitle='Curso Básico de Canto Lírico' percentageConcluded={55} />
                    <section className='create-post'>
                        <img className='post-photo' src={foto} />
                        <input className='post-input' placeholder='Escreva Uma Postagem' />
                    </section>
                    <section className='post'>
                        <h1 className='post-title'>Título do Artigo</h1>
                        <p className='post-text'>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
                        <img className='post-image' src={grupoAbaArtigos} />
                    </section>
                </main>
                <div className='barra-navegacao-grupos'>
                    <GroupsNavbar />
                </div>
            </div>
        </div>
    );
}