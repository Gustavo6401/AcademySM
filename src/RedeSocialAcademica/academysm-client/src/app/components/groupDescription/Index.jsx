import React from 'react';
import './Index.css'

/**
 * 
 * @param {string} icon
 * @param {string} courseTitle
 * @param {number} percentageConcluded
 * @returns {JSX.Element}
 */
function GroupDescription({ icon, courseTitle, percentageConcluded }) {
    return (
        <section className='group-description'>
            <div className='groupCategoryIcon'>
                <i className={icon}></i>
            </div>
            <div className='description'>
                <h1>{courseTitle}</h1>
                <label className='conclusionPercentage'>{percentageConcluded}% Concluído</label>
                <div className='barra-conclusao'>
                    <div className='barra-demonstrativa'></div>
                </div>
            </div>
        </section>
    );
}

export default GroupDescription;