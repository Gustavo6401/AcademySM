import './Index.css'

function AcademySMText({ title, text, component1, component2, component3 }) {
    return (
        <div className='academySMText'>
            <div className='academySMTitle'>
                <h1 className='fontMedium'>{title}</h1>
            </div>
            <div className='academySMDescriptionText'>
                <p className='fontMedium'>{text}</p>
            </div>
            <div className='academySMAditionalComponent-1'>
                {component1}
            </div>
            <div className='academySMAditionalComponent-2'>
                {component2}
            </div>
            <div className='academySMAditionalComponent-3'>
                {component3}
            </div>
        </div>
    );
}

export default AcademySMText;