import React from 'react';
import Navbar from '../../components/navbar/index'
import GroupsNavbar from '../../components/groupsNavbar/Index'
import './Index.css'
import AcademySMText from '../../components/academySMText/Index';

function Nota() {
    return (
        <label className='fontMedium'>Para - Dia 05/08/2024 - Nota - 2,0</label>
    )
}

function BotaoEnvio() {
    return (
        <button className='button-medium vermelho'>
            <i className='bi bi-file-earmark-plus-fill'></i> Adicionar Envio
        </button>
    )
}

export default function Tarefa() {
    return (
        <div>
            <Navbar />
            <div className='paginaTarefa'>
                <main className='taskPage'>
                    <section className='voltarAbaTarefas'>
                        <div className='fontExtraLarge'>
                            <i className='bi bi-clipboard-check-fill'></i>
                        </div>
                        <label className='fontMedium'>Voltar � Aba Tarefas</label>
                    </section>
                    <section>
                        <AcademySMText
                            title='Aprenda a Abertura Ruy Lopez - Tarefa Atrasada'
                            text='A abertura Ruy Lopez � important�ssima para cada jogador de xadrez e o objetivo dessa li��o � que voc� aprenda os prop�sitos de cada lance e de como jogar contra essa abertura nos n�veis iniciais. Fa�a uma reda��o mostrando as ideias dessa abertura.'
                            component1={<Nota />}
                            component2={<BotaoEnvio />}
                        />
                    </section>
                </main>
                <div className='barra-navegacao-grupos'>
                    <GroupsNavbar />
                </div>
            </div>            
        </div>
    );
}