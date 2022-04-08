import React, { useEffect, useState } from "react";

import {
  Flex,
  Box,
  FormControl,
  FormLabel,
  Select,
  Input,
  Button,
} from "@chakra-ui/react";

const form = {
  transactionId: Number,
  description: String,
  amount: Number,
  transactionCategoryId: Number,
};

const FinanceUpdate = ({
  transactions,
  setTransactions,
  transactionCategories,
  selectedTransaction,
}) => {
  useEffect(() => {
    let tempTransaction = transactions.find(
      (trans) => trans.transactionId == selectedTransaction
    );
    if (tempTransaction !== undefined) setTransaction(tempTransaction);
  }, [selectedTransaction]);
  const [transaction, setTransaction] = useState({ ...form });

  const handleSubmit = (event) => {
    console.log(transaction);
    fetch("/api/finance", {
      method: "PUT",
      headers: {
        Authorization: window.sessionStorage.getItem("token"),
        "Content-type": "application/json",
      },
      body: JSON.stringify({
        TransactionId: transaction.transactionId,
        Description: transaction.description,
        Amount: transaction.amount,
        TransactionCategoryId: transaction.transactionCategoryId,
      }),
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
      });
    event.preventDefault();
  };
  const handleDelete = () => {
    fetch("/api/finance", {
      method: "DELETE",
      headers: {
        Authorization: window.sessionStorage.getItem("token"),
        "Content-type": "application/json",
      },
      body: JSON.stringify(transaction.transactionId),
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
      });
  };
  return (
    <>
      <Flex mt="5" width="full" justifyContent="end" alignItems="top">
        <Box
          p="8"
          maxWidth="1000px"
          borderWidth="1"
          borderRadius="12"
          boxShadow="lg"
        >
          <form onSubmit={handleSubmit}>
            <FormControl isRequired>
              <FormLabel>Transaction type</FormLabel>
              <Select
                onChange={(event) =>
                  setTransaction({
                    ...transaction,
                    transactionCategoryId: parseInt(event.currentTarget.value),
                  })
                }
                value={transaction.transactionCategoryId}
                placeholder="Select option"
              >
                {transactionCategories.map((cat) => {
                  return (
                    <option value={cat.transactionCategoryId}>
                      {cat.name}
                    </option>
                  );
                })}
              </Select>
            </FormControl>
            <FormControl isRequired>
              <FormLabel>Description</FormLabel>
              <Input
                type="text"
                onChange={(event) =>
                  setTransaction({
                    ...transaction,
                    description: event.currentTarget.value,
                  })
                }
                value={transaction.description}
              />
            </FormControl>
            <FormControl isRequired>
              <FormLabel>Amount</FormLabel>
              <Input
                type="text"
                onChange={(event) =>
                  setTransaction({
                    ...transaction,
                    amount: parseInt(event.currentTarget.value),
                  })
                }
                value={transaction.amount}
              />
            </FormControl>
            <Button width="full" mt={4} type="submit">
              Update
            </Button>
            <Button width="full" mt={4} type="button" onClick={handleDelete}>
              Delete
            </Button>
          </form>
        </Box>
      </Flex>
    </>
  );
};

export default FinanceUpdate;
