import './Index.css'

export default function CourseStatus({ onChange }) {
    return (
        <select className='formInputType-1' onChange={onChange}>
            <option value='Concluído'>Concluído</option>
            <option value='Trancado'>Trancado</option>
            <option value='Cursando'>Cursando</option>
        </select>
    );
}