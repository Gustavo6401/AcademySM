import React from 'react';
import Navbar from '../../components/navbar/index'
import GrauFormacao from '../../components/formacaoAtual/Index'
import foto from '../../assets/image/foto_gustavo.webp'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap-icons/font/bootstrap-icons.css'
import './Index.css'
import EducationalBackground from '../../../domain/models/apis/user/educationalBackground';
import ViewFormation from '../../components/viewFormation/Index';
import CourseComponent from '../../components/courseComponent/Index';

function EditarCadastroUsuario() {
    /** @type {EducationalBackground} */
    var university = new EducationalBackground('', 'Análise e Desenvolvimento de Sistemas', 'Ensino Superior',
        'Concluído', 'Centro Universitário Senac', new Date(2021, 1, 10), new Date(2023, 5, 10))

    /**
     * 0 - January
     * 1 - February
     * 2 - March
     * 3 - April
     * 4 - May
     * 5 - June
     * 6 - July
     * 7 - August
     * 8 - September
     * 9 - October
     * 10 - November
     * 11 - December
     */
    /** @type {EducationalBackground} */
    var techinicalCourse = new EducationalBackground('', 'Informática', 'Ensino Médio Técnico', 'Concluído',
        'Instituto Social Nossa Senhora de Fátima', new Date(2019, 0, 28), new Date(2019, 11, 17))

    return (
        <div>
            <Navbar />
            <div className='editarDadosUsuario'>
                <div className='vertical-centralizer'>
                    <div className='editarUsuario'>
                        <h1>Dados Pessoais</h1>
                        <hr />
                        <div className='componentIsolator-1'>
                            <input className='formInputType-1' type='text' placeholder='Nome Completo' />
                        </div>
                        <div className='componentIsolator-1'>
                            <input className='formInputType-1' type='email' placeholder='E-Mail' />
                        </div>
                        <div className='componentIsolator-1'>
                            <input className='formInputType-1' type='password' placeholder='Senha' />
                        </div>
                        <div className='componentIsolator-1'>
                            <input className='formInputType-1' type='date' placeholder='Data de Nascimento' />
                        </div>
                        <div className='componentIsolator-1'>
                            <input className='formInputType-1' type='text' placeholder='Telefone (Com DDD)' />
                        </div>
                        <div className='componentIsolator-1'>
                            <GrauFormacao cssClass='formInputType-1' />
                        </div>
                        <div className='componentIsolator-1'>
                            <input className='formInputType-1' type='text' placeholder='Curso Atual' />
                        </div>
                        <div className='componentIsolator-1'>
                            <textarea className='textArea-1' placeholder='Currículo' />
                        </div>
                        <div className='componentIsolator-1'>
                            <input className='formInputType-1' type='text' placeholder='Instituição' />
                        </div>
                        <div className='componentIsolator-1'>
                            <button className='button-large azul-escuro'>Guardar Dados</button>
                        </div>
                    </div>
                </div>
                <div className='profilePicAndFormationsEditUserData'>
                    <div className='fotoPerfil'>
                        <img className='actualProfilePic' src={foto} />
                        <label>Modificar Foto de Perfil</label>
                    </div>
                    <ViewFormation educationalBackground={university} />
                    <ViewFormation educationalBackground={techinicalCourse} />
                </div>
                <div className='batePaposEmGrupo'>
                    <CourseComponent icon='bi bi-music-note-beamed' course='Canto Lírico' />
                    <CourseComponent icon='bi bi-hourglass-split' course='História do Mundo' />
                    <CourseComponent icon='bi bi-cpu-fill' course='TDD - Test Driven Development' />
                    <CourseComponent icon='bi bi-translate' course='Inglês Avançado' />
                    <CourseComponent icon='bi bi-pencil-fill' course='Desenhe Seus Retratos' />
                </div>
            </div>
        </div>
    );
}

export default EditarCadastroUsuario;