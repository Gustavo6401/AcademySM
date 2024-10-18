import React from 'react';
import EducationalBackground from '../../../domain/models/apis/user/educationalBackground'
import './Index.css'

/**
 * 
 * @param {EducationalBackground} educationalBackground
 * @returns
 */

/**
 * 
 * @param {Date} date
 * @returns {string}
 */
function formatDate(date) {
    const day = String(date.getDate()).padStart(2, '0');
    const month = String(date.getMonth() + 1).padStart(2, '0'); // January is 0!
    const year = date.getFullYear();
    return `${day}/${month}/${year}`;
}

function ViewFormation({ educationalBackground }) {
    return (
        <div className='viewFormation'>
            <div className='componentIsolator-1'>
                <label>Curso: {educationalBackground.getCourse()}</label>
            </div>
            <div className='componentIsolator-1'>
                <label>Grau Educacional: {educationalBackground.getEducationalBackground()}</label>
            </div>
            <div className='componentIsolator-1'>
                <label>Status: {educationalBackground.getStatus()}</label>
            </div>
            <div className='componentIsolator-1'>
                <label>Instituição: {educationalBackground.getInstitution()}</label>
            </div>
            <div className='componentIsolator-1'>
                <label>Início do Curso: {formatDate(educationalBackground.getCourseBegin())}</label>
            </div>
            <div className='componentIsolator-1'>
                <label>Fim do Curso: {formatDate(educationalBackground.getCourseEnd())}</label>
            </div>
            <div className='componentIsolator-1'>
                <button className='button-medium azul-escuro'>
                    <i className='bi bi-pencil-fill'></i>
                </button>
            </div>
        </div>
    );
}

export default ViewFormation;