import React from 'react';
import NavbarWhite from '../../components/navbarWhite/Index';
import GroupsNavbar from '../../components/groupsNavbar/Index'
import './ConteudoCurso.css'

function ConteudoCurso() {
    return (
        <div>
            <NavbarWhite />
            <div className='conteudoCurso'>
                <main className='conteudoCursoMainContent'>
                    <h1>Módulo 1</h1>
                    <hr/>
                    <section className='userClass'>
                        <div className='userClassButton'>
                            <i className='bi bi-folder-fill'></i>
                        </div>
                        <div className='classDescription'>
                            <h1 className='classTitle'>Aula 1 - Movimentos do Xadrez</h1>
                            <div className='classFilesComponent'>
                                <div className='componentIsolator-1'>
                                    <button className='button-medium vermelho'>
                                        <i className='bi bi-file-earmark-word-fill'></i>  Movimentos.docx
                                    </button>
                                </div>
                                <div className='componentIsolator-1'>
                                    <button className='button-medium vermelho'>
                                        <i className='bi bi-file-ppt-fill'></i>  Movimentos.pptx
                                    </button>
                                </div>
                            </div>
                        </div>
                    </section>
                    <h2>Módulo 2</h2>
                    <hr />
                    <section className='userClass'>
                        <div className='userClassButton'>
                            <i className='bi bi-folder-fill'></i>
                        </div>
                        <div className='classDescription'>
                            <h1 className='classTitle'>Aula 1 - Como Funcionam as Aberturas</h1>
                            <div className='classFilesComponent'>
                                <div className='componentIsolator-1'>
                                    <button className='button-medium azul-escuro'>
                                        <i className='bi bi-file-earmark-word-fill'></i>  Aberturas.docx
                                    </button>
                                </div>
                                <div className='componentIsolator-1'>
                                    <button className='button-medium azul-escuro'>
                                        <i className='bi bi-file-ppt-fill'></i>  Aberturas.pptx
                                    </button>
                                </div>
                            </div>
                        </div>
                    </section>
                </main>
                <section className='barra-navegacao-grupos'>
                    <GroupsNavbar />
                </section>
            </div>
        </div>
    );
}

export default ConteudoCurso;