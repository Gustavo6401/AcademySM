import React from 'react';
import './Index.css'

export default function CourseStatus({ value, onChange }) {
    return (
        <select className='formInputType-1' value={value} onChange={onChange}>
            <option value='Concluído'>Concluído</option>
            <option value='Trancado'>Trancado</option>
            <option value='Cursando'>Cursando</option>
        </select>
    );
}