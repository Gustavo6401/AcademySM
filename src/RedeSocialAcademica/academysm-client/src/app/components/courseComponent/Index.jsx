import React from 'react';

/**
 * 
 * @param {string} icon
 * @param {string} course
 * @returns
 */
function CourseComponent({ icon, course }) {
    return (
        <div className='courseComponent'>
            <div className='smallCircle branco'>
                <i className={icon}></i>
            </div>
            <label className='courseLabel'>{course}</label>
        </div>
    );
}

export default CourseComponent;