import { ChangeEvent, useEffect, useState } from "react";
import Category from "../../../domain/models/apis/groups/category";
import CreateGroupViewServices from "../../services/createGroupViewServices";
import './CreateGroups.css'
import CategoriesMenu from "../../components/categoriesMenu/Index";
import Courses from "../../../domain/models/apis/groups/courses";

interface CreateGroupsModalProps {
    isOpen: boolean
    onClose: () => void
}

const CreateGroupsModal: React.FC<CreateGroupsModalProps> = ({ isOpen, onClose }) => {
    const [name, setName] = useState<string>('')
    const [level, setLevel] = useState<string>('')
    const [tutor, setTutor] = useState<string>('')
    const [description, setDescription] = useState<string>('')
    const [isPublic, setIsPublic] = useState<boolean>(false)
    
    const [selectedCategoryId, setSelectedCategoryId] = useState<number | null>(null)

    const [categories, setCategories] = useState<Array<Category> | undefined>(undefined)

    const services: CreateGroupViewServices = new CreateGroupViewServices()

    const handleBooleanConvertion = (e: ChangeEvent<HTMLInputElement>, functionParameter: Function) => {
        const booleanValue: string = e.target.value
        const parsedValue: boolean = Boolean(booleanValue)
        functionParameter(parsedValue)
    }

    const handleCategorySelect = (categoryId: number) => {
        setSelectedCategoryId(categoryId)
    }

    const handleRegisterGroup = async () => {
        if (selectedCategoryId === null) {
            alert('Nenhuma Categoria Foi Selecionada!')

            return            
        } 

        var group: Courses = new Courses(0, name, level, tutor, description, isPublic, '')

        var response = await services.create(group, selectedCategoryId)

        alert(`${response}`)
    }

    useEffect(() => {
        setCategories(services.categoryList())
    }, [])

    if (!isOpen) return null

    return (
        <div className='modal'>
            <div className='modal-container'>
                <div className='modalHeader'>
                    <h2 className='modal-title'>Cadastro de Grupos</h2>
                    <button className='modal-close-button' onClick={onClose}>X</button>
                </div>
                <div className='cadastroGrupo'>
                    <div className='componentIsolator-1'>
                        <input className='formInputType-1' type='text' placeholder='Nome do Curso' onChange={e => setName(e.target.value)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <select className='formInputType-1' onChange={e => setLevel(e.target.value)}>
                            <option value='Básico'>Básico</option>
                            <option value='Intermediário'>Intermediário</option>
                            <option value='Avançado'>Avançado</option>
                        </select>
                    </div>
                    <div className='componentIsolator-1'>
                        <input className='formInputType-1' type='text' placeholder='Nome do Tutor' onChange={e => setTutor(e.target.value)} />
                    </div>
                    <div className='componentIsolator-1'>
                        <textarea className='textArea-1' placeholder='Descrição' onChange={e => setDescription(e.target.value)}></textarea>
                    </div>
                    <div className='componentIsolator-1'>
                        {categories ? <CategoriesMenu categories={categories} onCategorySelect={handleCategorySelect} /> : 'Carregando'}
                    </div>
                    <div>
                        <input type='checkbox' onChange={e => handleBooleanConvertion(e, setIsPublic)} /> <label>É um Curso Público?</label>
                    </div>
                    <div className='componentIsolator-1'>
                        <button className='button-medium azul-escuro' onClick={handleRegisterGroup}>Cadastre Aqui.</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default CreateGroupsModal;