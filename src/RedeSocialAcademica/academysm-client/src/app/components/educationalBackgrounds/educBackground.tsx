import './eduBackground.css'

interface EducationalBackgroundProps {
    course: string,
    educationalDegree: string,
    status: string,
    institution: string,
    courseBegin: Date,
    courseEnd: Date,
}

const EduBackground: React.FC<EducationalBackgroundProps> = 
    ({ course, educationalDegree, status, institution, courseBegin, courseEnd }) => {
    return (
        <div className="edu-backgrounds">
            <div>
                <label>Curso: {course}</label>
            </div>
            <div>
                <label>Grau Educacional: {educationalDegree}</label>
            </div>
            <div>
                <label>Status: {status}</label>
            </div>
            <div>
                <label>Instituição: {institution}</label>
            </div>
            <div>
                <label>Início: {new Date(courseBegin).getDate()}/{new Date(courseBegin).getMonth()}/{new Date(courseBegin).getFullYear()}</label>
            </div>
            <div>
                <label>Fim: {new Date(courseEnd).getDate()}/{new Date(courseEnd).getMonth()}/{new Date(courseEnd).getFullYear()}</label>
            </div>
        </div>
    )
}

export default EduBackground