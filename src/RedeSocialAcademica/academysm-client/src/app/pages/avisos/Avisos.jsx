import React from 'react';
import './Avisos.css'
import NavbarWhite from '../../components/navbarWhite/Index'
import AcademySMText from '../../components/academySMText/Index'
import GroupsNavbar from '../../components/groupsNavbar/Index'

function Avisos() {
    return (
        <div>
            <NavbarWhite />
            <div className='avisos'>
                <main className='avisosMainContent'>
                    <div className='createNewAviso'>
                        <button className='button-medium vermelho'>Criar Novo Aviso</button>
                    </div>
                    <section className='avisos'>
                        <AcademySMText
                            title={'Dia - 07/08/2024'}
                            text={'Caros alunos, aviso para vocês que nesse dia 07/08 não haverá aula, simplesmente quartou e vamos voltar só na segunda. \n \n Prof. Gustavo'}
                        />
                    </section>
                </main>
                <section className='barra-navegacao-grupos'>
                    <GroupsNavbar />
                </section>
            </div>
        </div>
    );
}

export default Avisos;