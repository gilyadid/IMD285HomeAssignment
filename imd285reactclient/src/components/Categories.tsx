import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState, AppDispatch } from '../store';
import { fetchCategories } from '../store/actions';
import { Category } from "../store/categoriesSlice";
import './Categories.css';

export interface CategoriesProps {
    onCategorySelect: (categoryId: string) => void;
}

const Categories: React.FC<CategoriesProps> = ({ onCategorySelect }) => {
    const dispatch: AppDispatch = useDispatch();
    const { categories, status, error } = useSelector((state: RootState) => state.categories);

    React.useEffect(() => {
        if (status === 'idle') {
            dispatch(fetchCategories());
        }
    }, [dispatch, status]);

    const handleSelectChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        onCategorySelect(event.target.value);
    };

    if (status === 'loading') {
        return <div>Loading...</div>;
    }

    if (status === 'failed') {
        return <div>Error: {error}</div>;
    }

    return (
        <div>
            <label className="categoryChoiceLabel" htmlFor="category">קטגוריות</label>
            <select id="category" onChange={handleSelectChange}>
                <option value="">בחר קטגוריה</option>
                {categories.map((category: Category) => (
                    <option key={category.id} value={category.id}>
                        {category.hebrewName}
                    </option>
                ))}
            </select>
        </div>
    );
};

export default Categories;
