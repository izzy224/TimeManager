import React, { useState } from "react";
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
  description: String,
  amount: Number,
  transactionCategoryId: Number,
};

const FinanceInsert = ({
  transactionCategories,
  walletId,
  date,
  setTransactions,
  transactions,
}) => {
  const [transaction, setTransaction] = useState({ ...form });
  const handleSubmit = () => {
    let tempDate = new Date(date);
    tempDate.setHours(1);
    console.log(transaction);
    fetch("api/finance", {
      method: "POST",
      headers: {
        Authorization: window.sessionStorage.getItem("token"),
        "Content-type": "application/json",
      },
      body: JSON.stringify({
        ...transaction,
        walletId: walletId,
        date: tempDate.toISOString(),
      }),
    })
      .then((response) => response.json())
      .then((data) => console.log(data));
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
              />
            </FormControl>
            <Button width="full" mt={4} type="submit">
              Insert
            </Button>
          </form>
        </Box>
      </Flex>
    </>
  );
};

export default FinanceInsert;
