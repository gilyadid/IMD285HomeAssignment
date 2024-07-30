import React from 'react';

interface NavigateToOrderProps {
    onNavigate: () => void;
    isCartEmpty: boolean;
}

const NavigateToOrder: React.FC<NavigateToOrderProps> = ({ onNavigate, isCartEmpty }) => {
    return (
        <div>
            <button onClick={onNavigate} disabled={isCartEmpty}>
                המשך להזמנה
            </button>
        </div>
    );
};

export default NavigateToOrder;
