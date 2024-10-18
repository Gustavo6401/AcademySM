import Category from "../../../domain/models/apis/groups/category";

interface CategoriesMenuProps {
    categories: Array<Category>,
    onCategorySelect: (categoryId: number) => void
}

const CategoriesMenu: React.FC<CategoriesMenuProps> = ({ categories, onCategorySelect }) => {
    const handleChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        const selectedCategoryId: number = parseInt(event.target.value, 10)
        onCategorySelect(selectedCategoryId)
    }

    return (
        <select className='categoriesMenu' onChange={handleChange}>
            {categories.map(item =>
                <option value={item.getId()}>
                    <div className='categoriesMenuIconCircle'>
                        <i className={item.getIcon()}></i>
                    </div>
                    <label className='categoiesMenuNameCategory'>{item.getId()} - {item.getName()}, {item.getMainCategory()}</label>
                </option>
            )}
        </select>
    );
}

export default CategoriesMenu;